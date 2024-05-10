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
        <div>
            <table width='100%'>
            <caption>
            Table de correspondances
            </caption>
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
        </div>
    );
}
export default MatchingTable