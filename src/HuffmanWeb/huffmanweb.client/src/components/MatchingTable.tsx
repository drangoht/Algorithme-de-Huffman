import { Button, Modal, Tooltip } from "@mui/material";
import { CharactersListProps } from "../Interfaces/CharactersListProps";
import CharacterIListtem from "./CharacterIListItem";
import JsonModal from "./JsonModal";
import { useState } from "react";

const MatchingTable = ({ characters }: CharactersListProps) => {
  if (!characters?.length) {
    return (
      <div>
        <p className="notice">Rien dans la table de correspondances</p>
      </div>
    );
  }
  const [open, setOpen] = useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  return (
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
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
        className="modal"
      >
        <JsonModal jsonString={JSON.stringify(characters)} />
      </Modal>
    </details>
  );
};
export default MatchingTable;
