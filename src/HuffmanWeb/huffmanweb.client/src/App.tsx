/* eslint-disable */
import { useState } from "react";
import "./App.css";
import Encode from "./components/Encode/Encode";

function App() {
  const [tab, setTab] = useState("encode");

  return (
    <div>
      <button onClick={() => setTab("encode")}>Encoder</button>
      <button onClick={() => setTab("decode")}>Decoder</button>
      <div className={tab === "encode" ? "tab-visible" : "tab-hidden"}>
        <Encode />
      </div>
      <div className={tab === "decode" ? "tab-visible" : "tab-hidden"}>
        decode
      </div>
    </div>
  );
}

export default App;
