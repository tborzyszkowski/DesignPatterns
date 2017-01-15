//
//  SkladnikiTableViewController.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 14/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import UIKit

class CistoCell: UITableViewCell {
    @IBOutlet var ciastoNameLabel: UILabel!
    @IBOutlet var ciastoPrzepisLabel: UILabel!
}

class CiastoTableViewController: UITableViewController {

    var ciasto: Ciasto?

    let avaiableCakes: [Ciasto.Type] = [
        CiastoPan.self,
        CiastoTradycyjne.self,
        CiastoTradycyjneZSerem.self,
        CiastoMurzynek.self // <- dzieki adapterowi :)
    ]

    override func viewDidLoad() {
        super.viewDidLoad()
        tableView.rowHeight = UITableViewAutomaticDimension
        tableView.estimatedRowHeight = 140
    }

    // MARK: - Table view data source
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return avaiableCakes.count
    }

    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        guard let cell = tableView.dequeueReusableCell(withIdentifier: "ChooseSkladnikCellID", for: indexPath) as? CistoCell else { fatalError("Cant dequeu cell") }
        let currentCake = avaiableCakes[indexPath.row].init()
        cell.ciastoNameLabel?.text = currentCake.name
        cell.ciastoPrzepisLabel?.text = currentCake.przepis

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
