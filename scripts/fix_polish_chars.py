#!/usr/bin/env python3
"""
Fix common missing Polish diacritics in Markdown files under given directories.
Scans files, excludes fenced code blocks, inline code, and link targets.
Writes changes in-place and prints a JSON summary to stdout.
"""
import os
import re
import sys
import json

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), '..'))
TARGET_DIRS = [os.path.join(ROOT, 'src', '08-fasada'), os.path.join(ROOT, 'src', '09-most')]

# Mapping of ASCII-only forms -> corrected Polish forms
MAPPING = {
    'niezalezne': 'niezależne',
    'podejsciu': 'podejściu',
    'kazda': 'każda',
    'urzadzenia': 'urządzenia',
    'urzadzenie': 'urządzenie',
    'zrobic': 'zrobić',
    'wlacz': 'włącz',
    'glosnosc': 'głośność',
    'wykonac': 'wykonać',
    'dotkniec': 'dotknięć',
    'zycia': 'życia',
    'obiektow': 'obiektów',
    'pilotow': 'pilotów',
    'urzadzen': 'urządzeń',
    'tresc': 'treść',
    'powiazany': 'powiązany',
    'reguly': 'reguły',
    'bezpieczenstwa': 'bezpieczeństwa',
    'kanalki': 'kanały',
    'dotkniety': 'dotknięty',
    'dzialaja': 'działają',
    'providerow': 'providerów',
    'alertow': 'alertów',
    'kanalow': 'kanałów',
    'powiadomien': 'powiadomień',
    'napisac': 'napisać',
    'wywolan': 'wywołań',
    'strukture': 'strukturę',
    'napisac': 'napisać',
    'powiazane': 'powiązane'
}

# Sort keys by length desc to avoid partial replacements
KEYS = sorted(MAPPING.keys(), key=len, reverse=True)

fenced_re = re.compile(r'```[\s\S]*?```', re.MULTILINE)
inline_code_re = re.compile(r'`[^`]*`')
inline_link_re = re.compile(r'\[[^\]]*\]\([^\)]*\)')
angle_link_re = re.compile(r'<[^>]+>')
ref_def_re = re.compile(r'^[ \t]*\[[^\]]+\]:\s*(\S.*)$', re.MULTILINE)

word_boundary = lambda k: re.compile(r'\b' + re.escape(k) + r'\b', re.IGNORECASE)


def merge_intervals(intervals):
    if not intervals:
        return []
    intervals = sorted(intervals)
    merged = [intervals[0]]
    for a, b in intervals[1:]:
        last_a, last_b = merged[-1]
        if a <= last_b:
            merged[-1] = (last_a, max(last_b, b))
        else:
            merged.append((a, b))
    return merged


def preserve_case(orig, repl):
    if orig.isupper():
        return repl.upper()
    if orig[0].isupper():
        return repl[0].upper() + repl[1:]
    return repl


def process_file(path):
    with open(path, 'r', encoding='utf-8') as f:
        text = f.read()
    orig_text = text
    n = len(text)
    excluded = []

    # fenced code
    for m in fenced_re.finditer(text):
        excluded.append((m.start(), m.end()))
    # inline code
    for m in inline_code_re.finditer(text):
        excluded.append((m.start(), m.end()))
    # inline links - mask the parentheses part to avoid replacing inside targets
    for m in inline_link_re.finditer(text):
        # find opening paren inside match
        s = m.group(0)
        # find '(' position relative to match
        paren_idx = s.find('(')
        if paren_idx >= 0:
            start = m.start() + paren_idx + 1
            end = m.end() - 1
            if start < end:
                excluded.append((start, end))
    # angle links
    for m in angle_link_re.finditer(text):
        excluded.append((m.start(), m.end()))
    # reference definitions RHS
    for m in ref_def_re.finditer(text):
        # group 1 is RHS
        excluded.append((m.start(1), m.end(1)))

    excluded = merge_intervals(excluded)

    # build included spans
    included = []
    last = 0
    for a, b in excluded:
        if last < a:
            included.append((last, a))
        last = b
    if last < n:
        included.append((last, n))

    total_changes = 0
    changes = []

    new_parts = []
    for a, b in included:
        seg = text[a:b]
        seg_changes = []
        for k in KEYS:
            pat = word_boundary(k)
            def repl(m):
                return preserve_case(m.group(0), MAPPING[k])
            seg, cnt = pat.subn(repl, seg)
            if cnt:
                seg_changes.append((k, MAPPING[k], cnt))
                total_changes += cnt
        new_parts.append((a, b, seg, seg_changes))

    if total_changes == 0:
        return None

    # Reconstruct text
    out = []
    last = 0
    for a, b, seg, seg_changes in new_parts:
        if last < a:
            out.append(text[last:a])
        out.append(seg)
        last = b
    if last < n:
        out.append(text[last:])
    new_text = ''.join(out)

    with open(path, 'w', encoding='utf-8', newline='\n') as f:
        f.write(new_text)

    # collect change summary
    file_changes = []
    for a, b, seg, seg_changes in new_parts:
        file_changes.extend(seg_changes)
    summary = {}
    for k, v, cnt in file_changes:
        summary.setdefault(k + ' -> ' + v, 0)
        summary[k + ' -> ' + v] += cnt
    return {'path': path, 'changes': summary, 'total': total_changes}


def main():
    results = []
    for d in TARGET_DIRS:
        for root, dirs, files in os.walk(d):
            for fn in files:
                if fn.lower().endswith('.md'):
                    path = os.path.join(root, fn)
                    try:
                        res = process_file(path)
                        if res:
                            results.append(res)
                    except Exception as e:
                        print(json.dumps({'error': str(e), 'file': path}), file=sys.stderr)
    print(json.dumps(results, ensure_ascii=False, indent=2))

if __name__ == '__main__':
    main()
