import { useState } from "react";

/**
 * Custom hook for managing textarea form state
 * @param initialValue - Initial value for the textarea
 * @returns Object containing value, change handler, reset function, and setValue
 */
export function useTextareaForm(initialValue = "") {
    const [value, setValue] = useState(initialValue);

    const handleChange = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
        setValue(event.target.value);
    };

    const reset = () => setValue(initialValue);

    return { value, handleChange, reset, setValue };
}
