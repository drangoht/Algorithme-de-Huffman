import {
  Button,
  Tooltip,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import { TreeProps } from "../../Interfaces/Encode/TreeProps";
import TreeChildren from "./TreeChildren";
import JsonModal from "./JsonModal";
import { useState } from "react";
import { Link } from "../../dtos/Link";

const Tree = ({ graph }: TreeProps) => {
  if (graph != undefined) {
    const rootLinks = graph.links.filter(
      (link: Link) => link.parent.identifier == graph.root.identifier,
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
        <Dialog
          open={open}
          onClose={handleClose}
          aria-labelledby="alert-dialog-title"
          aria-describedby="alert-dialog-description"
          sx={{
            background: "#212121",
            color: "#dcdcdc",
            "& .MuiPaper-root": {
              background: "#212121",
              color: "#dcdcdc",
            },
            "& .MuiBackdrop-root": {
              backgroundColor: "transparent",
              color: "#dcdcdc",
            },
          }}
        >
          <DialogTitle>Arbre en JSON</DialogTitle>
          <DialogContent>
            <JsonModal jsonString={JSON.stringify(graph)} />
          </DialogContent>
        </Dialog>
      </details>
    );
  }
};
export default Tree;
