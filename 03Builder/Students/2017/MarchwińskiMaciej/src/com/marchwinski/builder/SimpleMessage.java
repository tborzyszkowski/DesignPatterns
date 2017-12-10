package com.marchwinski.builder;

public class SimpleMessage {

    private String from;
    private String to;
    private String content;
    private String date;

    public SimpleMessage(SimpleMessageBuilder builder) {
        this.from = builder.from;
        this.to = builder.to;
        this.content = builder.content;
        this.date = builder.date;
    }

    public String getFrom() {
        return from;
    }

    public String getTo() {
        return to;
    }

    public String getContent() {
        return content;
    }

    public String getDate() {
        return date;
    }

    static class SimpleMessageBuilder {
        private String from;
        private String to;
        private String content;
        private String date;

        public SimpleMessageBuilder() {
        }

        public SimpleMessage build() {
            return new SimpleMessage(this);
        }

        public SimpleMessageBuilder from(String from){
            this.from = from;
            return this;
        }

        public SimpleMessageBuilder to(String to){
            this.to = to;
            return this;
        }
        public SimpleMessageBuilder content(String content){
            this.content = content;
            return this;
        }
        public SimpleMessageBuilder date(String date){
            this.date = date;
            return this;
        }
    }
}
