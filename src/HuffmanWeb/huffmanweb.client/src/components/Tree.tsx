import { Button, Modal, Tooltip } from "@mui/material";
import { TreeProps } from "../Interfaces/TreeProps";
import TreeChildren from "./TreeChildren";
import JsonModal from "./JsonModal";
import { useState } from "react";

const Tree = ({ graph }: TreeProps) => {
  if (graph != undefined) {
    const rootLinks = graph.links.filter(
      (link) => link.parent.identifier == graph.root.identifier,
    );
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    return (
      <details>
        <summary>Arbre</summary>
        <div className="notice">
          <div className="right-action">
            <Tooltip title="Visualisation du JSON">
              <Button onAnimationEnd={handleOpen}>JSON</Button>
            </Tooltip>
          </div>
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
        </div>
        <Modal
          open={open}
          onClose={handleClose}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
          className="modal"
        >
          <JsonModal jsonString={JSON.stringify(graph)} />
        </Modal>
      </details>
    );
  }
};
export default Tree;
