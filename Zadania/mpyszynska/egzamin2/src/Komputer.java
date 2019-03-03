public class Komputer extends Product {


    public Komputer() {
        super.name = "Komputer1";
        super.cena = 320;
    }


    public void visit(Raport visitable) {
        System.out.println("Dodany komputer");
    }


}
