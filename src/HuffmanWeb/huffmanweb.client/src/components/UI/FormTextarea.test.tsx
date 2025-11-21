import { describe, it, expect, vi } from "vitest";
import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import FormTextarea from "./FormTextarea";

describe("FormTextarea", () => {
    it("renders with label", () => {
        render(
            <FormTextarea
                label="Test Label"
                value=""
                onChange={vi.fn()}
            />
        );

        expect(screen.getByText("Test Label")).toBeInTheDocument();
    });

    it("renders textarea with correct value", () => {
        render(
            <FormTextarea
                label="Test"
                value="Test value"
                onChange={vi.fn()}
            />
        );

        const textarea = screen.getByRole("textbox");
        expect(textarea).toHaveValue("Test value");
    });

    it("calls onChange when user types", async () => {
        const handleChange = vi.fn();
        const user = userEvent.setup();

        render(
            <FormTextarea
                label="Test"
                value=""
                onChange={handleChange}
            />
        );

        const textarea = screen.getByRole("textbox");
        await user.type(textarea, "Hello");

        expect(handleChange).toHaveBeenCalled();
    });

    it("applies default cols and rows", () => {
        render(
            <FormTextarea
                label="Test"
                value=""
                onChange={vi.fn()}
            />
        );

        const textarea = screen.getByRole("textbox");
        expect(textarea).toHaveAttribute("cols", "75");
        expect(textarea).toHaveAttribute("rows", "10");
    });

    it("applies custom cols and rows", () => {
        render(
            <FormTextarea
                label="Test"
                value=""
                onChange={vi.fn()}
                cols={50}
                rows={5}
            />
        );

        const textarea = screen.getByRole("textbox");
        expect(textarea).toHaveAttribute("cols", "50");
        expect(textarea).toHaveAttribute("rows", "5");
    });

    it("displays error message when error prop is provided", () => {
        render(
            <FormTextarea
                label="Test"
                value=""
                onChange={vi.fn()}
                error="This is an error"
            />
        );

        expect(screen.getByText("This is an error")).toBeInTheDocument();
        expect(screen.getByText("This is an error")).toHaveClass("error");
    });

    it("does not display error when error prop is undefined", () => {
        const { container } = render(
            <FormTextarea
                label="Test"
                value=""
                onChange={vi.fn()}
            />
        );

        const errorDiv = container.querySelector(".error");
        expect(errorDiv).not.toBeInTheDocument();
    });

    it("updates value when controlled", () => {
        const { rerender } = render(
            <FormTextarea
                label="Test"
                value="Initial"
                onChange={vi.fn()}
            />
        );

        expect(screen.getByRole("textbox")).toHaveValue("Initial");

        rerender(
            <FormTextarea
                label="Test"
                value="Updated"
                onChange={vi.fn()}
            />
        );

        expect(screen.getByRole("textbox")).toHaveValue("Updated");
    });
});
