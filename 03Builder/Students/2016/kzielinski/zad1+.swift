//  Builders
//
//  Created by Kamil Zielinski on 17/11/16.
//

// Builder with Closure 

class Graph: CustomStringConvertible {
    var color: String!
    var type: String!
    var width: String!
    var height: String!

    typealias BuildClosure = (Graph) -> ()

    init(build: BuildClosure) {
        build(self)
    }

    var description: String { return "Type: \(type!)  Color: \(color!)  Width: \(width!) Height: \(height!)" }
}

let buildedGraph = Graph { (graph) in
    graph.color = "Blue"
    graph.type = "PieChart"
    graph.width = "100px"
    graph.height = "150px"
}

print(buildedGraph)

let PinkHistogramGraphBuilder: (Graph) -> () = { graph in
    graph.color = "Pink"
    graph.type = "Histogram"
    graph.width = "300px"
    graph.height = "450px"
}

let buildedGraphWithExternalClosure = Graph(build: PinkHistogramGraphBuilder)

print(buildedGraphWithExternalClosure)