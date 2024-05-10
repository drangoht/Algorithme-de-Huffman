﻿import { SizeStatsProps } from "../Interfaces/SizeStatsProps";

const SizeStats = ({ originalSize, encodedSize }: SizeStatsProps) => {
    const gain: string = ((1 - (encodedSize / originalSize)) * 100).toFixed(2)
    return (originalSize > 0 ?
        <div>
            <p className="notice">
                <div>
                    Taille d'origine: {originalSize.toString()} bits
                </div>
                <div>
                    Taille encodée: {encodedSize.toString()} bits
                </div>
                <div>
                    Gain: {gain}%
                </div>
            </p>
        </div>:<div></div>
    );
}
export default SizeStats