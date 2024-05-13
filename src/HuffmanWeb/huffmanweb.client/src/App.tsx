//import { useEffect, useState } from 'react';
import { useState } from "react";
import './App.css';
/*import { CharactersListProps } from './Interfaces/CharactersListProps';*/
import MatchingTable from './components/MatchingTable';
import TextToEncodeForm from './components/TextToEncodeForm';
import { textToEncodeResponse, weightedGraph } from "./dtos/textToEncodeResponse";
import { Character } from "./dtos/Character";
import SizeStats from "./components/SizeStats";
import Tree from "./components/Tree";


function App() {
    let responseEncoded : textToEncodeResponse
    const [chars, setChars] = useState<Character[]>()
    const [encodedSize, setEncodedSize] = useState(0)
    const [originalSize, setOriginalSize] = useState(0)
    const [graph, setGraph] = useState<weightedGraph>()
    return (<div>
        <TextToEncodeForm onEncodeText={onEncodeText} />
        <SizeStats encodedSize={encodedSize} originalSize={originalSize } />
        <MatchingTable characters={chars || []} />
        <Tree graph={graph!} />
        </div>
    );

    async function onEncodeText(textToEncode : string) {
        const form = new FormData();
        form.append("textToEncode", textToEncode);
        await fetch('https://localhost:7134/huffman/encode', {
            method: 'POST', headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ textToEncode: textToEncode })
        }).then(async response  => {
            if (!response.ok) {
                throw new Error(response.statusText)
            }
            responseEncoded = await response.json()
            setEncodedSize(responseEncoded.encodedSize)
            setOriginalSize(responseEncoded.originalSize)
            setGraph(responseEncoded.graph)
            console.log(responseEncoded.graph)
            let chars: Character[] = []
            responseEncoded.matchingCharacters.forEach(function (chr) {
                chars.push({id: chr.id,value:chr.value})
            })
            setChars(chars)
        }).catch((error: Error) => {
            console.log(error)
            throw error
        })
    }
    
}

export default App;