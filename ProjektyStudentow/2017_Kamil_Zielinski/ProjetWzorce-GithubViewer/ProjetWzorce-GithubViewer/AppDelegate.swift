//
//  AppDelegate.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 14/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import UIKit

@UIApplicationMain
class AppDelegate: UIResponder, UIApplicationDelegate {

    var window: UIWindow?

    func application(_ application: UIApplication, didFinishLaunchingWithOptions launchOptions: [UIApplicationLaunchOptionsKey: Any]?) -> Bool {
        return true
    }

    func applicationWillTerminate(_ application: UIApplication) {
        CoreDataManager.shearedInstance.saveContext()
    }
}

