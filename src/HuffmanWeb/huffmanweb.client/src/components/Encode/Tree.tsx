import { useState } from "react";
import {
  Accordion, AccordionSummary, AccordionDetails,
  Button, Tooltip, Dialog, DialogContent, DialogTitle,
} from "@mui/material";
import ExpandMoreRoundedIcon from "@mui/icons-material/ExpandMoreRounded";
import DataObjectRoundedIcon from "@mui/icons-material/DataObjectRounded";
import { TreeProps } from "../../Interfaces/Encode/TreeProps";
import TreeChildren from "./TreeChildren";
import JsonModal from "./JsonModal";
import { Link } from "../../dtos/Link";
import { removeNullChar } from "../../utils/stringUtils";
import "../../tree.css";

const Tree = ({ graph }: TreeProps) => {
  const [open, setOpen] = useState(false);

  if (!graph) return null;

  const rootLinks = graph.links.filter(
    (link: Link) => link.parent.identifier === graph.root.identifier,
  );

  return (
    <>
      <Accordion defaultExpanded>
        <AccordionSummary expandIcon={<ExpandMoreRoundedIcon />}>
          Arbre de Huffman
        </AccordionSummary>
        <AccordionDetails>
          <div className="right-action" style={{ marginBottom: 10 }}>
            <Tooltip title="Voir le JSON">
              <Button
                size="small"
                variant="outlined"
                startIcon={<DataObjectRoundedIcon />}
                onClick={() => setOpen(true)}
                sx={{ borderColor: 'rgba(0,212,255,0.3)', color: '#00D4FF', '&:hover': { borderColor: '#00D4FF', bgcolor: 'rgba(0,212,255,0.06)' } }}
              >
                JSON
              </Button>
            </Tooltip>
          </div>
          <div className="tree-container">
            <div className="tree">
              <ul>
                <li>
                  <div>
                    {removeNullChar(graph.root.character)}:{graph.root.nbOccurence}
                  </div>
                  <TreeChildren children={rootLinks} graph={graph} />
                </li>
              </ul>
            </div>
          </div>
        </AccordionDetails>
      </Accordion>

      <Dialog open={open} onClose={() => setOpen(false)} aria-labelledby="tree-dialog-title">
        <DialogTitle id="tree-dialog-title">Arbre — JSON</DialogTitle>
        <DialogContent>
          <JsonModal jsonString={JSON.stringify(graph)} />
        </DialogContent>
      </Dialog>
    </>
  );
};
export default Tree;
