import { useState } from "react";
import {
  Accordion, AccordionSummary, AccordionDetails,
  Button, Tooltip, Dialog, DialogContent, DialogTitle,
} from "@mui/material";
import ExpandMoreRoundedIcon from "@mui/icons-material/ExpandMoreRounded";
import DataObjectRoundedIcon from "@mui/icons-material/DataObjectRounded";
import { CharactersListProps } from "../../Interfaces/Encode/CharactersListProps";
import CharacterIListtem from "./CharacterIListItem";
import JsonModal from "./JsonModal";

const MatchingTable = ({ characters }: CharactersListProps) => {
  const [open, setOpen] = useState(false);

  if (!Array.isArray(characters) || characters.length === 0) return null;

  return (
    <>
      <Accordion defaultExpanded>
        <AccordionSummary expandIcon={<ExpandMoreRoundedIcon />}>
          Table de correspondances
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
          <table className="steampunk-table" style={{ width: '100%' }}>
            <thead>
              <tr>
                <th>Caractère</th>
                <th>Valeur</th>
              </tr>
            </thead>
            <tbody>
              {characters.map(({ id, value }) => (
                <CharacterIListtem key={id} id={id} value={value} />
              ))}
            </tbody>
          </table>
        </AccordionDetails>
      </Accordion>

      <Dialog open={open} onClose={() => setOpen(false)} aria-labelledby="match-dialog-title">
        <DialogTitle id="match-dialog-title">Table de correspondance — JSON</DialogTitle>
        <DialogContent>
          <JsonModal jsonString={JSON.stringify(characters)} />
        </DialogContent>
      </Dialog>
    </>
  );
};
export default MatchingTable;
