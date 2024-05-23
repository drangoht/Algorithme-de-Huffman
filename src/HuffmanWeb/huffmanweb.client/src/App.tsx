/* eslint-disable */
import { useState } from "react";
import "./App.css";
import Encode from "./components/Encode/Encode";
import Decode from "./components/Decode/Decode";
function App() {
  const [tab, setTab] = useState("encode");

  return (
    <div>
      <div className="tab-buttons">
        <div>
          <button
            disabled={tab === "encode" ? true : false}
            onClick={() => setTab("encode")}
            className="button-tab"
          >
            Encodage de texte
          </button>
        </div>
        <div>
          <button
            disabled={tab === "decode" ? true : false}
            onClick={() => setTab("decode")}
            className="button-tab"
          >
            Decodage du binaire
          </button>
        </div>
      </div>
      <div className={tab === "encode" ? "tab-visible" : "tab-hidden"}>
        <Encode />
      </div>
      <div className={tab === "decode" ? "tab-visible" : "tab-hidden"}>
        <Decode />
      </div>
    </div>
  );
}

export default App;
