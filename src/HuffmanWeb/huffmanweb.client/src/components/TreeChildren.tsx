import { TreeChildrenProps } from "../Interfaces/TreeChildrenProps";
import { huffmanNode } from "../dtos/textToEncodeResponse";

const TreeChildren = ({ children, graph }: TreeChildrenProps) => {
    let leftChild: huffmanNode | undefined = undefined
    let rightChild: huffmanNode | undefined = undefined
    if (children!.length == 2) {
        leftChild = graph.allNodes.find((node) => node.identifier == children[0].child.identifier)
        rightChild = graph.allNodes.find((node) => node.identifier == children[1].child.identifier)
    }
    if (children.length == 1) {
        leftChild = graph.allNodes.find((node) => node.identifier == children[0].child.identifier)
    }

    const leftChildren = graph.links.filter((link) => link.parent.identifier == leftChild!.identifier)
    const rightChildren = graph.links.filter((link) => link.parent.identifier == rightChild!.identifier)
    return (<>
                <ul>
            {leftChild != null ?? <li>
                <span className="weight">0</span><div>{leftChild!.character}:{leftChild!.nbOccurence}</div>
                {leftChildren != undefined ?? <TreeChildren children={leftChildren} graph={graph} />}
            </li>}
            {rightChild != null ?? <li>
                <span className="weight">0</span><div>{rightChild!.character}:{rightChild!.nbOccurence}</div>
                {rightChildren != undefined ?? <TreeChildren children={rightChildren} graph={graph} />}
            </li>}
            
                </ul>
        </>) 
}
export default TreeChildren

