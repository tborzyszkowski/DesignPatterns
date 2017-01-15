//
//  SkladnikiTableViewController.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 14/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import UIKit

class CiastoTableViewController: UITableViewController {

    var ciasto: Ciasto?

    let avaiableCakes: [Ciasto.Type] = [
        CiastoPan.self,
        CiastoTradycyjne.self,
        CiastoTradycyjneZSerem.self,
        CiastoMurzynek.self // <- dzieki adapterowi :)
    ]

    // MARK: - Table view data source
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return avaiableCakes.count
    }

    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "ChooseSkladnikCellID", for: indexPath)

        cell.textLabel?.text = avaiableCakes[indexPath.row].init().name

        return cell
    }

    // MARK: - Table view delegate
    override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        ciasto = avaiableCakes[indexPath.row].init()
        _ = self.navigationController?.popViewController(animated: true)
        if let vc = self.navigationController?.topViewController as? PizzaViewController {
            vc.ciasto = ciasto
        }
    }
}
