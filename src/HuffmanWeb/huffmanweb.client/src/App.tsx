/* eslint-disable */
import { useState } from "react";
import "./App.css";
import Encode from "./components/Encode/Encode";
import Decode from "./components/Decode/Decode";
import SteampunkLayout from "./components/Layout/SteampunkLayout";
import SteampunkButton from "./components/UI/SteampunkButton";

function App() {
  const [tab, setTab] = useState("encode");

  return (
    <SteampunkLayout>
      <div className="app-header">
        <h1>Huffman Machine</h1>
        <div className="divider-ornament"></div>
      </div>

      <div className="tab-buttons">
        <SteampunkButton
          label="Encodage de texte"
          isActive={tab === "encode"}
          onClick={() => setTab("encode")}
        />
        <SteampunkButton
          label="Decodage binaire"
          isActive={tab === "decode"}
          onClick={() => setTab("decode")}
        />
      </div>

      <div className="content-panel">
        <div className={`tab-content ${tab === "encode" ? "visible" : "hidden"}`}>
          <Encode />
        </div>
        <div className={`tab-content ${tab === "decode" ? "visible" : "hidden"}`}>
          <Decode />
        </div>
      </div>
    </SteampunkLayout>
  );
}

export default App;
