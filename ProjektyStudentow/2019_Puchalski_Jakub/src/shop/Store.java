package shop;

import watchModels.Watch;
import watchModels.WatchModels;

import java.util.*;

public class Store {

    private static Store instance = null;
    private Map<WatchModels, List<Watch>> store = new HashMap<>();

    private Store(){}

    public static Store getInstance() {
        if (instance == null){
            instance = new Store();
        } else {
            return instance;
        }
            return instance;
    }

    public void showStore(){
        Iterator<Map.Entry<WatchModels,List<Watch>>> entries = store.entrySet().iterator();
        while (entries.hasNext()){
            Map.Entry<WatchModels,List<Watch>> entry = entries.next();
            System.out.println("Model = " + entry.getKey() + ", amount = " + entry.getValue().size());
        }
    }

    public void showStoreDetails(){
        Iterator<Map.Entry<WatchModels,List<Watch>>> entries = store.entrySet().iterator();
        while (entries.hasNext()){
            Map.Entry<WatchModels,List<Watch>> entry = entries.next();
            for (int i = 0; i < entry.getValue().size(); i++){
                System.out.println(entry.getValue().get(i));
            }
        }
    }

    public void addWatch(Watch watch){
        if (store.get(watch.model) == null){
            ArrayList<Watch> arrayList = new ArrayList<>();
            arrayList.add(watch);
            store.put(watch.model,arrayList);
            System.out.println("added new Type of models.Watch");
        } else {
            store.get(watch.model).add(watch);
            System.out.println("adden new watch");
        }
    }

    public void addWatch(ArrayList<Watch> watches){
        if (store.get(watches.get(0).model) == null){
            ArrayList<Watch> arrayList = new ArrayList<>();
            arrayList.addAll(watches);
            store.put(watches.get(0).model,arrayList);
            System.out.println("added new Type of models.Watch");
        } else {
            store.get(watches.get(1).model).addAll(watches);
            System.out.println("adden new watch");
        }
    }

    public Watch getWatch(WatchModels watchModel){
        Watch watch = store.get(watchModel).get(0);
        return watch;
    }

    public ArrayList<Watch> getWatch(WatchModels watchModel, int amount){
        ArrayList<Watch> arrayList = new ArrayList<>();
        for (int i = 0; i<amount; i++){
            arrayList.add(store.get(watchModel).get(0));
        }

        return arrayList;
    }

    public void removeFromMagazine(long watchId){
        Iterator<Map.Entry<WatchModels,List<Watch>>> entries = store.entrySet().iterator();
        while (entries.hasNext()){
            Map.Entry<WatchModels,List<Watch>> entry = entries.next();
            for (int i = 0; i < entry.getValue().size(); i++){
                    if (entry.getValue().get(i).id == watchId)
                    entry.getValue().remove(i);
            }
        }
        }



}
