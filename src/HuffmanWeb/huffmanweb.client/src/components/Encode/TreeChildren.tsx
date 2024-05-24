import { TreeChildrenProps } from "../../Interfaces/Encode/TreeChildrenProps";
import { HuffmanNode } from "../../dtos/HuffmanNode";
import { Link } from "../../dtos/Link";
const TreeChildren = ({ children, graph }: TreeChildrenProps) => {
  let leftChild: HuffmanNode | undefined = undefined;
  let rightChild: HuffmanNode | undefined = undefined;
  if (children!.length == 2) {
    leftChild = graph.allNodes.find(
      (node: HuffmanNode) => node.identifier == children[0].child.identifier,
    );
    rightChild = graph.allNodes.find(
      (node: HuffmanNode) => node.identifier == children[1].child.identifier,
    );
  }
  if (children.length == 1) {
    leftChild = graph.allNodes.find(
      (node: HuffmanNode) => node.identifier == children[0].child.identifier,
    );
  }

  const leftChildren =
    leftChild != undefined
      ? graph.links.filter(
          (link: Link) => link.parent.identifier == leftChild!.identifier,
        )
      : [];
  const rightChildren =
    rightChild != undefined
      ? graph.links.filter(
          (link: Link) => link.parent.identifier == rightChild!.identifier,
        )
      : [];
  return (
    <>
      <ul>
        {leftChild != undefined ? (
          <li>
            <span className="weight">0</span>
            <div>
              <b>{leftChild!.character.replace("\x00", "")}</b>:
              {leftChild!.nbOccurence}
            </div>
            {leftChildren.length > 0 ? (
              <TreeChildren children={leftChildren} graph={graph} />
            ) : (
              <></>
            )}
          </li>
        ) : (
          <></>
        )}
        {rightChild != undefined ? (
          <li>
            <span className="weight">1</span>
            <div>
              <b>{rightChild!.character.replace("\x00", "")}</b>:
              {rightChild!.nbOccurence}
            </div>
            {rightChildren.length > 0 ? (
              <TreeChildren children={rightChildren} graph={graph} />
            ) : (
              <></>
            )}
          </li>
        ) : (
          <></>
        )}
      </ul>
    </>
  );
};
export default TreeChildren;
