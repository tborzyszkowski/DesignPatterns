package com.marchwinski.builder;

import com.marchwinski.builder.fluent.FluentMessage;

public final class TestMethods {
    private TestMethods() {
        //prevents instantiation
    }

    // Kolejność bez znaczenia, mozna nadpisywać
    public static void testSimpleMessageBuilder() {
        SimpleMessage.SimpleMessageBuilder simpleMessageBuilder = new SimpleMessage.SimpleMessageBuilder();
        SimpleMessage messageInvitation = simpleMessageBuilder
                .from("Stefan")//can be whatever
                .to("Barabara")
                .content("Dinner invitation")
                .from("Stefan2")
                .date("2017-09-13")
                .build();
        System.out.println("----    MESSAGE         ----");
        System.out.println("---- DATE : " + messageInvitation.getDate() + "  ----");
        System.out.println("---- FROM : " + messageInvitation.getFrom() + "  ----");
        System.out.println("---- TO :   " + messageInvitation.getTo() + " ----");
        System.out.println("---- CONTENT :  " + messageInvitation.getContent() + "    ----");
        System.out.println("----    END MESSAGE     ----");
    }


    // KOlejność narzucona, dobrze flow
    public static void testFluentMessageBuilder() {
        FluentMessage flutentMessage = FluentMessage
                .date("2017")
                .from("Stefan")
                .to("Barbararara")
                .content("Nice invitation")
                .build();



        System.out.println("----    MESSAGE         ----");
        System.out.println("---- DATE : " + flutentMessage.getDate() + "  ----");
        System.out.println("---- FROM : " + flutentMessage.getFrom() + "  ----");
        System.out.println("---- TO :   " + flutentMessage.getTo() + " ----");
        System.out.println("---- CONTENT :  " + flutentMessage.getContent() + "    ----");
        System.out.println("----    END MESSAGE     ----");
    }

}
