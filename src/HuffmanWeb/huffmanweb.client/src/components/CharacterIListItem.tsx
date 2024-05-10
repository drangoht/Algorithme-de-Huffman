import { Character } from "../Interfaces/CharactersListProps"

const CharacterIListtem = ({ id, value }: Character) => {
    return (
        <li>
            <div>
                <div>
                    <h2>{id} - {value}</h2>
                </div>
            </div>
        </li>
    )
}
export default CharacterIListtem