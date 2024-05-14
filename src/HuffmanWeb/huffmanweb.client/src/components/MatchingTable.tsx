import { CharactersListProps } from "../Interfaces/CharactersListProps";
import CharacterIListtem from "./CharacterIListItem";

const MatchingTable = ({ characters }: CharactersListProps) => {
  if (!characters?.length) {
    return (
      <div>
        <p className="notice">Rien dans la table de correspondances</p>
      </div>
    );
  }
  return (
    <details>
      <summary>Table de correspondances</summary>
      <div>
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
    </details>
  );
};
export default MatchingTable;
