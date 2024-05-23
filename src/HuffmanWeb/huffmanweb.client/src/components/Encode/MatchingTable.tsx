import { CharactersListProps } from "../../Interfaces/Encode/CharactersListProps";
import CharacterIListtem from "./CharacterIListItem";
import JsonModal from "./JsonModal";
import { useState } from "react";
import {
  Button,
  Tooltip,
  Dialog,
  DialogContent,
  DialogTitle,
} from "@mui/material";

const MatchingTable = ({ characters }: CharactersListProps) => {
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return Array.isArray(characters) && characters.length > 0 ? (
    <details>
      <summary>Table de correspondances</summary>
      <div className="notice">
        <div className="right-action">
          <Tooltip title="Visualisation du JSON">
            <Button onAnimationEnd={handleOpen}>JSON</Button>
          </Tooltip>
        </div>
        <table width="100%">
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
        <DialogTitle>Table de correspondance en JSON</DialogTitle>
        <DialogContent>
          <JsonModal jsonString={JSON.stringify(characters)} />
        </DialogContent>
      </Dialog>
    </details>
  ) : (
    <></>
  );
};
export default MatchingTable;
