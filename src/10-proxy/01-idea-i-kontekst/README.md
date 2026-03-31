# 01. Idea i kontekst wzorca Proxy

## Cel tematu

Zrozumiec, kiedy chcemy podstawic obiekt posredniczacy przed obiekt docelowy.

## Problem

Klient nie powinien zawsze:

1. miec pelnego dostepu do RealSubject,
2. inicjalizowac ciezkich zasobow od razu,
3. znac szczegolow infrastruktury zdalnej.

## Idea Proxy

Proxy ma ten sam kontrakt co RealSubject, ale dodaje kontrolowany punkt wejscia.

1. Client -> ISubject.
2. Proxy : ISubject.
3. RealSubject : ISubject.

## Typowe zastosowania

1. Protection Proxy: autoryzacja.
2. Virtual Proxy: lazy initialization.
3. Remote Proxy: ukrycie komunikacji sieciowej.
4. Caching/Logging Proxy: cross-cutting concerns.

## Co odroznia od innych wzorcow

1. Adapter zmienia interfejs, Proxy zachowuje ten sam.
2. Dekorator glownie rozszerza zachowanie, Proxy glownie kontroluje dostep.
