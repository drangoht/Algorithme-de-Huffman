import { Character } from "./Character"

export interface textToEncodeResponse  {
    graph : weightedGraph
    matchingCharacters : Character[]
    encodedSize: number
    originalSize: number
    encodedBinaryString : string
}
export interface weightedGraph {
    root: huffmanNode
    allNodes : huffmanNode[]
    links : link[]
}
export interface huffmanNode {
     identifier : string
     character : string
     nbOccurence : number
}
export interface link {
    weight : number
    parent : huffmanNode
    child : huffmanNode
}