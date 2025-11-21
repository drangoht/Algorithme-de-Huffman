import { describe, it, expect } from "vitest";
import { renderHook, act } from "@testing-library/react";
import { useTextareaForm } from "./useTextareaForm";

describe("useTextareaForm", () => {
    it("initializes with empty string by default", () => {
        const { result } = renderHook(() => useTextareaForm());

        expect(result.current.value).toBe("");
    });

    it("initializes with provided initial value", () => {
        const { result } = renderHook(() => useTextareaForm("Initial text"));

        expect(result.current.value).toBe("Initial text");
    });

    it("updates value when handleChange is called", () => {
        const { result } = renderHook(() => useTextareaForm());

        act(() => {
            const event = {
                target: { value: "New text" },
            } as React.ChangeEvent<HTMLTextAreaElement>;
            result.current.handleChange(event);
        });

        expect(result.current.value).toBe("New text");
    });

    it("resets to initial value when reset is called", () => {
        const { result } = renderHook(() => useTextareaForm("Initial"));

        act(() => {
            const event = {
                target: { value: "Changed" },
            } as React.ChangeEvent<HTMLTextAreaElement>;
            result.current.handleChange(event);
        });

        expect(result.current.value).toBe("Changed");

        act(() => {
            result.current.reset();
        });

        expect(result.current.value).toBe("Initial");
    });

    it("allows setting value directly with setValue", () => {
        const { result } = renderHook(() => useTextareaForm());

        act(() => {
            result.current.setValue("Direct value");
        });

        expect(result.current.value).toBe("Direct value");
    });

    it("handles multiple value changes", () => {
        const { result } = renderHook(() => useTextareaForm());

        act(() => {
            result.current.setValue("First");
        });
        expect(result.current.value).toBe("First");

        act(() => {
            result.current.setValue("Second");
        });
        expect(result.current.value).toBe("Second");

        act(() => {
            const event = {
                target: { value: "Third" },
            } as React.ChangeEvent<HTMLTextAreaElement>;
            result.current.handleChange(event);
        });
        expect(result.current.value).toBe("Third");
    });

    it("reset works correctly after setValue", () => {
        const { result } = renderHook(() => useTextareaForm("Original"));

        act(() => {
            result.current.setValue("Modified");
        });

        act(() => {
            result.current.reset();
        });

        expect(result.current.value).toBe("Original");
    });
});
