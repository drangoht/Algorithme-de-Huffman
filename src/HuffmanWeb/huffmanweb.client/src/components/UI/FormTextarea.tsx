import React from "react";

interface FormTextareaProps {
    label: string;
    value: string;
    onChange: (event: React.ChangeEvent<HTMLTextAreaElement>) => void;
    cols?: number;
    rows?: number;
    error?: string;
}

/**
 * Reusable textarea component for forms
 */
const FormTextarea: React.FC<FormTextareaProps> = ({
    label,
    value,
    onChange,
    cols = 75,
    rows = 10,
    error,
}) => {
    return (
        <label>
            {label}
            {error && <div className="error">{error}</div>}
            <textarea cols={cols} rows={rows} value={value} onChange={onChange} />
        </label>
    );
};

export default FormTextarea;
