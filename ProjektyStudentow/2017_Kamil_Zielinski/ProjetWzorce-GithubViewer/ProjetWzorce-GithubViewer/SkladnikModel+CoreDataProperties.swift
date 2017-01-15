//
//  SkladnikModel+CoreDataProperties.swift
//  
//
//  Created by Kamil Zielinski on 15/01/2017.
//
//  This file was automatically generated and should not be edited.
//

import Foundation
import CoreData


extension SkladnikModel {

    @nonobjc public class func fetchRequest() -> NSFetchRequest<SkladnikModel> {
        return NSFetchRequest<SkladnikModel>(entityName: "SkladnikModel");
    }

    @NSManaged public var name: String?
    @NSManaged public var pizza: PizzaModel?

}
