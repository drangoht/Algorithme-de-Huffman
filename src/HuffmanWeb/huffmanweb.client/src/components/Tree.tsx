import { TreeProps } from "../Interfaces/TreeProps";
import TreeChildren from "./TreeChildren";

const Tree = ({ graph }: TreeProps) => {
  if (graph != undefined) {
    const rootLinks = graph.links.filter(
      (link) => link.parent.identifier == graph.root.identifier,
    );

    return (
      <details>
        <summary>Arbre</summary>
        <div className="tree-container">
          <div className="tree">
            <ul>
              <li>
                <div>
                  {graph.root.character.replace("\x00", "")}:
                  {graph.root.nbOccurence}
                </div>
                <TreeChildren children={rootLinks} graph={graph} />
              </li>
            </ul>
          </div>
        </div>
      </details>
    );
  }
};
export default Tree;
