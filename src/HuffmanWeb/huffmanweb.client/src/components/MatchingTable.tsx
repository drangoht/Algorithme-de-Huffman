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
        <ul>
            {characters.map(({ id,value }) => (
                <CharacterIListtem
                    key={id}
                    id={id}
                    value={value} />
            ))}
        </ul>
    );
}
export default MatchingTable