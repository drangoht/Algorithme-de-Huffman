import { Character } from "./Character"

export interface textToEncodeResponse  {
    matchingCharacters : Character[]
    encodedSize : BigInt
    originalSize : BigInt
    encodedBinaryString : string
}
