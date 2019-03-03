public class Myszka extends Product implements Visitor {

    public Myszka() {
        super.name = "Myszka1";
        super.cena = 32;
    }



    public void visit(Raport visitable) {
        System.out.println("dodano");
    }
}
