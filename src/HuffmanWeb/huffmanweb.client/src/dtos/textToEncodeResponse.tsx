import { Character } from "./Character"

export interface textToEncodeResponse  {
    matchingCharacters : Character[]
    encodedSize: number
    originalSize: number
    encodedBinaryString : string
}
