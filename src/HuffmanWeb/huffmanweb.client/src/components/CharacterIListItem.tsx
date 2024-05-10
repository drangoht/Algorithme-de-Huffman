import { Character } from "../dtos/Character"


const CharacterIListtem = ({ id, value }: Character) => {
    return (
        <tr>
            <td>
                {id}
            </td>
            <td>
                {value}
            </td>
        </tr>
    )
}
export default CharacterIListtem