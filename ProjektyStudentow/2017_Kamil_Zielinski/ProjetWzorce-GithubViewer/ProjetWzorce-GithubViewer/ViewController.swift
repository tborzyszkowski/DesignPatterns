//
//  ViewController.swift
//  ProjetWzorce-GithubViewer
//
//  Created by Kamil Zielinski on 14/01/2017.
//  Copyright © 2017 Kamil Zielinski. All rights reserved.
//

import UIKit
import CoreData

class PizzaSummaryTableCell : UITableViewCell {
    @IBOutlet var name: UILabel!
    @IBOutlet var skladniki: UILabel!
    @IBOutlet var shortCakeNameLabel: UILabel!
}

class ViewController: UIViewController {
    @IBOutlet var table: UITableView!
    var frc: NSFetchedResultsController<PizzaModel>!

    override func viewDidLoad() {
        super.viewDidLoad()
        let sortDesc = NSSortDescriptor(key: "name", ascending: true)
        let pizzaModelfetchRequest: NSFetchRequest<PizzaModel> = PizzaModel.fetchRequest()
        pizzaModelfetchRequest.sortDescriptors = [sortDesc]

        frc = NSFetchedResultsController(
            fetchRequest: pizzaModelfetchRequest,
            managedObjectContext: CoreDataManager.shearedInstance.managedObjectContext,
            sectionNameKeyPath: nil,
            cacheName: nil)

        frc.delegate = self

        RechabilityObservator.shearedInstance.add(observator: self)
    }

    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(animated)

        do { try frc.performFetch() } catch { print("Pobieranie pizzy nie wyszlo") }
        table.reloadData()
    }
}

extension ViewController: UITableViewDataSource {
    public func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return self.frc.sections![section].numberOfObjects
    }

    public func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "PizzaSummaryCellID", for: indexPath) as! PizzaSummaryTableCell

        configure(cell, atIndexPath: indexPath)

        return cell
    }

    fileprivate func configure(_ cell: PizzaSummaryTableCell, atIndexPath: IndexPath) {
        let pizzaModel = frc.object(at: atIndexPath)
        cell.name.text = pizzaModel.name
        cell.shortCakeNameLabel.text = pizzaModel.ciastoName?.initials
        if let pizzaSkladniki = pizzaModel.skladniki {
            let skladniki = pizzaSkladniki.map { skladnik -> String? in
                if skladnik is SkladnikModel {
                    return (skladnik as AnyObject).name
                }
                return nil
                }.flatMap { $0 }
            cell.skladniki.text = skladniki.joined(separator: ", ")

        }
    }
}

extension ViewController: NSFetchedResultsControllerDelegate {
    // MARK: -
    // MARK: Fetched Results Controller Delegate Methods
    func controllerWillChangeContent(_ controller: NSFetchedResultsController<NSFetchRequestResult>) {
        table.beginUpdates()
    }

    func controllerDidChangeContent(_ controller: NSFetchedResultsController<NSFetchRequestResult>) {
        table.endUpdates()
    }

    func controller(_ controller: NSFetchedResultsController<NSFetchRequestResult>, didChange anObject: Any, at indexPath: IndexPath?, for type: NSFetchedResultsChangeType, newIndexPath: IndexPath?) {
        switch (type) {
        case .insert:
            if let indexPath = newIndexPath {
                table.insertRows(at: [indexPath], with: .fade)
            }
            break;
        case .delete:
            if let indexPath = indexPath {
                table.deleteRows(at: [indexPath], with: .fade)
            }
            break;
        case .update:
            if let indexPath = indexPath {
                let cell = table.cellForRow(at: indexPath) as! PizzaSummaryTableCell
                configure(cell, atIndexPath: indexPath)
            }
            break;
        case .move:
            if let indexPath = indexPath {
                table.deleteRows(at: [indexPath], with: .fade)
            }

            if let newIndexPath = newIndexPath {
                table.insertRows(at: [newIndexPath], with: .fade)
            }
            break;
        }
    }
}

extension ViewController: InternetRechabilityObservator {
    func internetRachabilityChanged(to status: RechabilityObservator.Status) {
        var message: String!
        switch status {
        case .reachable:
            message = "Hurra jest internet!"
        case .notReachable:
            message = "Nie mam internetu!"
        }

        let alert = UIAlertController(title: "Alert", message: message, preferredStyle: .alert)
        alert.addAction(UIAlertAction(title: "Click", style:.default, handler: nil))
        self.present(alert, animated: true, completion: nil)
    }
}

