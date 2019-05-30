package PESEL;

import Person.Person;

public class PESEL implements iPesel {
    private String pesel = "";

    public PESEL() {
    }

    public PESEL(String pesel) {
        this.pesel = pesel;
    }

    @Override
    public void generate(Person person) {

        while (true) {
            this.pesel = new PeselBuilder()
                    .addDate(person.getDateOfBirth())
                    .addThreeRandoms()
                    .addSexNumber(person.getSex())
                    .addControlNumber()
                    .build();
            if (validate()) continue;
            break;
        }
        this.pesel = new PeselBuilder()
                .addDate(person.getDateOfBirth())
                .addThreeRandoms()
                .addSexNumber(person.getSex())
                .addControlNumber()
                .build();
    }

    @Override
    public boolean validate() {
        int[] pesel = stringToIntArray(this.pesel);
        int controlNumber = 0;
        int[] controlMultipliers = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1};
        for (int i = 0; i < 11; i++) {
            controlNumber += pesel[i] * controlMultipliers[i];
        }
        return (controlNumber % 10) == 0;
    }

    @Override
    public String toString() {
        return this.pesel;
    }

    private int[] stringToIntArray(String pesel) {
        int[] temp = new int[11];
        for (int i = 0; i < 11; i++) {
            temp[i] = Character.getNumericValue(pesel.charAt(i));
        }
        return temp;
    }

    private static int generateControlNumber(String PESELwithoutControlNumber) {
        int[] controlMultipliers = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1};
        int result = 0;
        for (int i = 0; i < 10; i++) {
            result += Character.getNumericValue(PESELwithoutControlNumber.charAt(i)) * controlMultipliers[i];
        }
        return 10 - result % 10;
    }

    public static class PeselBuilder {
        private String PESEL = "";

        PeselBuilder addDate(String date) {
            String[] elementsOfDate = date.split("-"); // date in format dd-mm-yyyy splitted
            PESEL = PESEL.concat(elementsOfDate[2].substring(2));
            PESEL = PESEL.concat(elementsOfDate[2].charAt(1) == '9' ? elementsOfDate[1] : (Character.getNumericValue(elementsOfDate[1].charAt(0)) + 2 + "" + elementsOfDate[1].charAt(1)));
            PESEL = PESEL.concat(elementsOfDate[0]);
            return this;
        }

        PeselBuilder addThreeRandoms() {
            int random1 = (int) (Math.random() * 9 + 1);
            int random2 = (int) (Math.random() * 9 + 1);
            int random3 = (int) (Math.random() * 9 + 1);
            PESEL = (PESEL + random1 + random2 + random3);
            return this;
        }

        PeselBuilder addSexNumber(Sex sex) {
            int sexNumber = 0;
            while (true) {
                sexNumber = (int) (Math.random() * (9 + 1));
                if (sex == Sex.MALE & (sexNumber % 2 == 0)) continue;
                else if (sex == Sex.FEMALE & (sexNumber % 2 != 0)) continue;
                break;
            }
            PESEL = (PESEL + sexNumber);
            return this;
        }

        PeselBuilder addControlNumber() {
            PESEL = PESEL + generateControlNumber(PESEL);
            return this;
        }

        String build() {
            return this.PESEL;
        }
    }
}


