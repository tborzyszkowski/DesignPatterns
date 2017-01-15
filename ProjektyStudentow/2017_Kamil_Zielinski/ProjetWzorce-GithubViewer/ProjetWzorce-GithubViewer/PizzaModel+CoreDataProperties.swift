//
//  PizzaModel+CoreDataProperties.swift
//  
//
//  Created by Kamil Zielinski on 15/01/2017.
//
//  This file was automatically generated and should not be edited.
//

import Foundation
import CoreData


extension PizzaModel {

    @nonobjc public class func fetchRequest() -> NSFetchRequest<PizzaModel> {
        return NSFetchRequest<PizzaModel>(entityName: "PizzaModel");
    }

    @NSManaged public var name: String?
    @NSManaged public var ciastoName: String?
    @NSManaged public var skladniki: Set<SkladnikModel>?

}
