//import { useEffect, useState } from 'react';
import { useState } from "react";
import './App.css';
/*import { CharactersListProps } from './Interfaces/CharactersListProps';*/
import MatchingTable from './components/MatchingTable';
import TextToEncodeForm from './components/TextToEncodeForm';
import { textToEncodeResponse } from "./dtos/textToEncodeResponse";
import { Character } from "./Interfaces/CharactersListProps";

function App() {
    let responseEncoded : textToEncodeResponse
    const [chars, setChars] = useState({ characters : [{  id: "toto", value:"tata" }, { id:"tutu", value:"tonton" }]})
    return (<div>
        <TextToEncodeForm onEncodeText={onEncodeText} />
        <MatchingTable characters={chars.characters} />
        </div>
    );

    async function onEncodeText(textToEncode : string) {
        const form = new FormData();
        form.append("textToEncode", textToEncode);
        const response = await fetch('https://localhost:7134/huffman/encode', {
            method: 'POST', headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ textToEncode: textToEncode })
        })
            if (!response.ok) {
                throw new Error(response.statusText)
            }
        responseEncoded = await response.json()
        console.log(responseEncoded)
        let chars: Character[]
        responseEncoded.matchingCharacters.forEach(function (value) {
            chars.push({id: value[0],value:value[1]})
        })
        setChars({ characters: chars })
    //        })
    //        .catch((error: Error) => {
    //            console.log(error)
    //            throw error
    //        })
    }
    
}

export default App;