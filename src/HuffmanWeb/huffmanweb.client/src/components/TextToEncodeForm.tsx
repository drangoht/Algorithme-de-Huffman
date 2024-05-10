import React, { useState, FormEvent } from 'react';


const TextToEncodeForm: React.FC<TextToEncodeFormProps> = (props) => {
    const [textareaValue, setTextareaValue] = useState('')

    const handleTextareaChange = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
        setTextareaValue(event.target.value);
    };

    const handleSubmit = (event: FormEvent) => {
        event.preventDefault();
        props.onEncodeText(textareaValue)
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>
                <h2>Veuillez saisir le texte à encoder:</h2>
                <textarea cols={75} rows={10 }
                    value={textareaValue}
                    onChange={handleTextareaChange}
                />
            </label>
            <div>
                <button type="submit">Encoder</button>
            </div>
        </form>
    );
};

export default TextToEncodeForm
