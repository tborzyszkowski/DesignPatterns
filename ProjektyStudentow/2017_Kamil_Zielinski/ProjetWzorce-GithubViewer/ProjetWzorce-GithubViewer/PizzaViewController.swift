//
//  PizzaViewController.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 14/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import Foundation
import UIKit

final class PizzaViewController: UIViewController {
    @IBOutlet var pizzaNameTextField: UITextField!
    @IBOutlet var table: UITableView!
    @IBOutlet var ciastoNameLabel: UILabel!
    @IBOutlet var dodajSkladnikTextField: UITextField!

    var ciasto:Ciasto!
    var skladniki:[String] = []

    override func viewDidLoad() {
        super.viewDidLoad()
        self.navigationItem.rightBarButtonItem = UIBarButtonItem(barButtonSystemItem: .done, target: self, action: #selector(doneButtonTapped))
    }

    @IBAction func dodajSkladnikButtonTapped(_ sender: Any) {
        if let skladnik = dodajSkladnikTextField.text, !skladnik.isEmpty {
            skladniki.append(skladnik)
            table.reloadData()
            dodajSkladnikTextField.text = nil
        }
    }

    func doneButtonTapped() {
        // Fluent builder :)
        let pizza = PizzaBuilder()
            .set(name: pizzaNameTextField.text ?? "")
            .set(ciasto: ciasto)
            .add(skladniki: skladniki)
            .getPizza()

        CoreDataManager.shearedInstance.add(pizza)
        _ = self.navigationController?.popViewController(animated: true)
    }

    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(animated)
        if ciasto == nil {
            ciasto = CiastoPan()
        }

        self.ciastoNameLabel.text = ciasto.name
    }

    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if let vc = segue.destination as? CiastoTableViewController {
            vc.ciasto = ciasto
        }
    }
}

extension PizzaViewController : UITableViewDataSource {
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return skladniki.count
    }

    public func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "SkladnikCellID", for: indexPath)

        cell.textLabel?.text = skladniki[indexPath.row]
        
        return cell
    }
}
