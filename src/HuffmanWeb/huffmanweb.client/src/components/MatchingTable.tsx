import { CharactersListProps } from "../Interfaces/CharactersListProps";
import CharacterIListtem from "./CharacterIListItem";

const MatchingTable = ({ characters }: CharactersListProps) => {
    if (!characters?.length) {
        return (
            <div>
                <h1>Rien dans la table de correspondance</h1>
            </div>
        );
    }
    return (
        <table>
            <thead>
                <tr>
                    <th>
                    Caractère
                    </th>
                    <th>
                    Valeur
                    </th>
                </tr>
            </thead>
            <tbody>
            {characters.map(({ id,value }) => (
                <CharacterIListtem
                    key={id}
                    id={id}
                    value={value} />
            ))}
            </tbody>
        </table>
    );
}
export default MatchingTable