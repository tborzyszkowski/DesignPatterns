namespace FluentBuilder.Emails;

// ============================================================
// FLUENT BUILDER — Email (przykład z "prawdziwego życia")
// ============================================================

public sealed class Email
{
    public string                From        { get; }
    public IReadOnlyList<string> To          { get; }
    public IReadOnlyList<string> Cc          { get; }
    public string                Subject     { get; }
    public string                Body        { get; }
    public bool                  IsHtml      { get; }
    public IReadOnlyList<string> Attachments { get; }

    private Email(Builder b)
    {
        From        = b.SenderAddress;
        To          = b.ToAddresses.AsReadOnly();
        Cc          = b.CcAddresses.AsReadOnly();
        Subject     = b.Subject;
        Body        = b.Body;
        IsHtml      = b.IsHtml;
        Attachments = b.Attachments.AsReadOnly();
    }

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"From   : {From}");
        sb.AppendLine($"To     : {string.Join(", ", To)}");
        if (Cc.Count > 0) sb.AppendLine($"Cc     : {string.Join(", ", Cc)}");
        sb.AppendLine($"Subject: {Subject}");
        sb.AppendLine($"Body   : {(IsHtml ? "[HTML] " : "")}{Body[..Math.Min(80, Body.Length)]}...");
        if (Attachments.Count > 0)
            sb.AppendLine($"Attach : {string.Join(", ", Attachments)}");
        return sb.ToString();
    }

    // ----- Builder -------------------------------------------

    public class Builder
    {
        public string       SenderAddress { get; private set; } = string.Empty;
        public List<string> ToAddresses   { get; } = [];
        public List<string> CcAddresses   { get; } = [];
        public string       Subject       { get; private set; } = string.Empty;
        public string       Body          { get; private set; } = string.Empty;
        public bool         IsHtml        { get; private set; }
        public List<string> Attachments   { get; } = [];

        public Builder From(string address)     { SenderAddress = address; return this; }
        public Builder To(string address)       { ToAddresses.Add(address); return this; }
        public Builder Cc(string address)       { CcAddresses.Add(address); return this; }
        public Builder WithSubject(string s)    { Subject = s; return this; }
        public Builder WithBody(string body)    { Body    = body; return this; }
        public Builder AsHtml()                 { IsHtml  = true; return this; }
        public Builder WithAttachment(string p) { Attachments.Add(p); return this; }

        public Email Build()
        {
            if (string.IsNullOrWhiteSpace(SenderAddress))
                throw new InvalidOperationException("Pole From jest wymagane");
            if (ToAddresses.Count == 0)
                throw new InvalidOperationException("Wymagany co najmniej jeden adresat To");
            if (string.IsNullOrWhiteSpace(Subject))
                throw new InvalidOperationException("Temat jest wymagany");
            return new Email(this);
        }
    }
}
