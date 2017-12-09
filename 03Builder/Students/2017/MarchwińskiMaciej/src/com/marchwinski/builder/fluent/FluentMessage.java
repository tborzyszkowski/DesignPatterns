package com.marchwinski.builder.fluent;

public class FluentMessage {

    private String from;
    private String to;
    private String content;
    private String date;

    private FluentMessage() {
    }

    public static IDate date(String date) {
        return new FluentMessage.FluentMessageBuilder(date);
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


    private static class FluentMessageBuilder implements IDate, IFrom, ITo, IContent {

        private final FluentMessage instance = new FluentMessage();

        public FluentMessageBuilder (String date){
            instance.date = date;
        }

        @Override
        public FluentMessage build() {
            return instance;
        }

        @Override
        public IFrom from(String from) {
            instance.from = from;
            return this;
        }

        @Override
        public ITo to(String to) {
            instance.to = to;
            return this;
        }

        @Override
        public IContent content(String content) {
            instance.content = content;
            return this;
        }
    }

}
