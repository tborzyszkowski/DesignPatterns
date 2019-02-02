package com.godziuk.app;

import com.godziuk.Warranty.AntiTheftProtection;
import com.godziuk.Warranty.BasicWarranty;
import com.godziuk.Warranty.ExtendedWarranty;
import com.godziuk.Warranty.Warranty;
import com.godziuk.app.Company.Company;
import com.godziuk.app.Employee.Employee;
import com.godziuk.app.Employee.Manager;
import com.godziuk.app.Factory.MercedesBuilderInterface;
import com.godziuk.app.Factory.Mercedes;
import com.godziuk.app.Factory.MercedesClassABuilder;
import com.godziuk.app.Factory.MercedesClassCBuilder;
import com.godziuk.app.Factory.MercedesClassEBuilder;
import com.godziuk.app.Factory.MercedesEngineer;
import com.godziuk.app.Store.MobileStore;
import com.godziuk.app.Store.MobileStoreAdapter;
import com.godziuk.app.Store.OnlineStore;
import com.godziuk.app.Store.OnlineStoreAdapter;
import com.godziuk.app.Store.Store;
import com.godziuk.app.Store.StoreInterface;
import java.util.ArrayList;
import java.util.List;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        //------------------------------- Creating company (Design patter used: Singleton) ------------------------------
        Company company_instance_1 = Company.getInstance();
        company_instance_1.setName("SuperTrader");
        
        //------------------------------- Creating different cars (Design patter used: Builder) ------------------------------
        //builders instances
        MercedesBuilderInterface aclassMercedes = new MercedesClassABuilder();
        MercedesBuilderInterface cclassMercedes = new MercedesClassCBuilder();
        MercedesBuilderInterface eclassMercedes = new MercedesClassEBuilder();
        
        //engineers instances
        MercedesEngineer aclassEngineer = new MercedesEngineer(aclassMercedes);
        MercedesEngineer cclassEngineer = new MercedesEngineer(cclassMercedes);
        MercedesEngineer eclassEngineer = new MercedesEngineer(eclassMercedes);
        
        //enginers creating cars
        aclassEngineer.makeMercedes();
        cclassEngineer.makeMercedes();
        eclassEngineer.makeMercedes();
        
        //cars instances
        Mercedes aclassMercedes_1 = aclassEngineer.getMercedes();
        
        Mercedes cclassMercedes_1 = cclassEngineer.getMercedes();
        Mercedes cclassMercedes_2 = cclassEngineer.getMercedes();
        
        Mercedes eclassMercedes_1 = eclassEngineer.getMercedes();
        Mercedes eclassMercedes_2 = eclassEngineer.getMercedes();
        Mercedes eclassMercedes_3 = eclassEngineer.getMercedes();
        
        //collectins cars to list
        List<Mercedes> cars = new ArrayList<>();
        cars.add(aclassMercedes_1);
        cars.add(cclassMercedes_1);
        cars.add(cclassMercedes_2);
        cars.add(eclassMercedes_1);
        cars.add(eclassMercedes_2);
        cars.add(eclassMercedes_3);
        
        
        //printing collected cars
        System.out.println("\nCars:");
        for(Mercedes car : cars){
            System.out.println(car.toString());
        }
        
        //------------------------------- Creating different stores (Design patter used: Adapter) ------------------------------
        Store store_1 = new Store();
        OnlineStore store_2 = new OnlineStore();
        OnlineStoreAdapter store_2_adapter = new OnlineStoreAdapter(store_2);
        MobileStore store_3 = new MobileStore();
        StoreInterface store_3_adapter = new MobileStoreAdapter(store_3);
        
        
        List<Mercedes> carsForStore_1 = new ArrayList<>();
        cars.add(aclassMercedes_1);
        cars.add(cclassMercedes_1);
        cars.add(eclassMercedes_1);
        store_1.setCars(carsForStore_1);
        store_1.setAddress("Warszawa ul.Domaniewska 44a");
        store_1.setSeller("Sprzedawca Mariusz");
        
        List<Mercedes> carsForStore_2 = new ArrayList<>();
        cars.add(cclassMercedes_2);
        cars.add(eclassMercedes_2);
        store_2_adapter.setCars(carsForStore_2);
        store_2_adapter.setAddress("www.mercedes-store.com");
        store_2_adapter.setSeller("Administrator Adrian");
        
        List<Mercedes> carsForStore_3 = new ArrayList<>();
        cars.add(eclassMercedes_3);
        store_3_adapter.setCars(carsForStore_3);
        store_3_adapter.setAddress("41°24'12.2\"N 2°10'26.5\"E");
        store_3_adapter.setSeller("Kierowca Łukasz");
        
        List<String> storesLocations = new ArrayList<>();
        storesLocations.add(store_1.getAddress());
        storesLocations.add(store_2_adapter.getAddress());
        storesLocations.add(store_3_adapter.getAddress());
        
        System.out.println("\nStores locations:");
        for(String location : storesLocations){
            System.out.println(location);
        }
        
        //testing singleton by adding stores to different company instances
        List<StoreInterface> s = company_instance_1.getStores();
        s.add(store_1);
        s.add(store_2_adapter);
        company_instance_1.setStores(s);
        
        System.out.println("\nCompany stores (instance 1):");
        for(StoreInterface si : company_instance_1.getStores()){
            System.out.println(si.getAddress());
        }
        
        System.out.println("\nSetting different stores to second company instance...");
        Company company_instance_2 = Company.getInstance();
        List<StoreInterface> s2 = new ArrayList<>();
        s2.add(store_3_adapter);
        company_instance_2.setStores(s2);
        
        System.out.println("\nCompany stores (instance 1) again:");
        for(StoreInterface si : company_instance_1.getStores()){
            System.out.println(si.getAddress());
        }
        
        //------------------------------- Creating warranty (Design patter used: Decorator) ------------------------------
        
        System.out.println("\nCars with warranty options selected:");
        Warranty warrantyOption_1 = new BasicWarranty();
        eclassMercedes_1.setWarranty(warrantyOption_1.create());
        System.out.println("Car 1: " + eclassMercedes_1.toString());
        
        Warranty warrantyOption_2 = new ExtendedWarranty(new BasicWarranty());
        eclassMercedes_2.setWarranty(warrantyOption_2.create());
        System.out.println("Car 2: " + eclassMercedes_2.toString());
        
        Warranty warrantyOption_3 = new AntiTheftProtection(new ExtendedWarranty(new BasicWarranty()));
        eclassMercedes_3.setWarranty(warrantyOption_3.create());
        System.out.println("Car 3: " + eclassMercedes_3.toString());
        
        //------------------------------- Setting working status (Design patter used: Observer) ------------------------------
        
        Employee e_1 = new Employee();
        e_1.setName("Adam Małysz");
        
        Employee e_2 = new Employee();
        e_2.setName("Jan Kowalski");
        
        System.out.println("\nEmployees:");
        System.out.println(e_1);
        System.out.println(e_2);
        
        Manager m = new Manager();
        m.attach(e_1);
        m.notifyEmployees();
        
        System.out.println("\nEmployees after setting working status:");
        System.out.println(e_1);
        System.out.println(e_2);
        
    }
}
