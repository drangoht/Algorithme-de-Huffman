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
            {leftChild != undefined ? <li>
                <span className="weight">0</span><div><b>{leftChild!.character.replace('\x00','')}</b>:{leftChild!.nbOccurence}</div>
                {leftChildren.length>0 ? <TreeChildren children={leftChildren} graph={graph} /> :<></>}
            </li>:<></>}
            {rightChild != undefined ? <li>
                <span className="weight">1</span><div><b>{rightChild!.character.replace('\x00', '')}</b>:{rightChild!.nbOccurence}</div>
                {rightChildren.length>0 ? <TreeChildren children={rightChildren} graph={graph} />:<></>}
            </li>:<></>}
            
                </ul>
        </>) 
}
export default TreeChildren

