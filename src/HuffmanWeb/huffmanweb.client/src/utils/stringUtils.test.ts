import { describe, it, expect } from "vitest";
import { removeNullChar } from "./stringUtils";

describe("stringUtils", () => {
    describe("removeNullChar", () => {
        it("removes null character from string", () => {
            const input = "Hello\x00World";
            const result = removeNullChar(input);
            expect(result).toBe("HelloWorld");
        });

        it("returns unchanged string when no null character present", () => {
            const input = "Hello World";
            const result = removeNullChar(input);
            expect(result).toBe("Hello World");
        });

        it("handles empty string", () => {
            const result = removeNullChar("");
            expect(result).toBe("");
        });

        it("removes only first null character", () => {
            const input = "\x00Test\x00String\x00";
            const result = removeNullChar(input);
            expect(result).toBe("Test\x00String\x00");
        });

        it("handles string with only null character", () => {
            const result = removeNullChar("\x00");
            expect(result).toBe("");
        });

        it("handles special characters", () => {
            const input = "Test\x00!@#$%";
            const result = removeNullChar(input);
            expect(result).toBe("Test!@#$%");
        });
    });
});
