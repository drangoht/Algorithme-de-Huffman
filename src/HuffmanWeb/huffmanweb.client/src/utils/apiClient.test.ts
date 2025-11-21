import { describe, it, expect, vi, beforeEach, afterEach } from "vitest";
import { apiPost } from "./apiClient";

describe("apiClient", () => {
    beforeEach(() => {
        global.fetch = vi.fn();
    });

    afterEach(() => {
        vi.restoreAllMocks();
    });

    describe("apiPost", () => {
        it("makes a POST request with correct headers and body", async () => {
            const mockResponse = { success: true, data: "test" };
            (global.fetch as any).mockResolvedValue({
                ok: true,
                json: async () => mockResponse,
            });

            const result = await apiPost("/test-endpoint", { key: "value" });

            expect(global.fetch).toHaveBeenCalledWith("/test-endpoint", {
                method: "POST",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ key: "value" }),
            });
            expect(result).toEqual(mockResponse);
        });

        it("returns typed response data", async () => {
            interface TestResponse {
                id: number;
                name: string;
            }

            const mockResponse: TestResponse = { id: 1, name: "Test" };
            (global.fetch as any).mockResolvedValue({
                ok: true,
                json: async () => mockResponse,
            });

            const result = await apiPost<TestResponse>("/test", {});

            expect(result.id).toBe(1);
            expect(result.name).toBe("Test");
        });

        it("throws error when response is not ok", async () => {
            (global.fetch as any).mockResolvedValue({
                ok: false,
                statusText: "Bad Request",
            });

            await expect(apiPost("/test", {})).rejects.toThrow("Bad Request");
        });

        it("handles network errors", async () => {
            (global.fetch as any).mockRejectedValue(new Error("Network error"));

            await expect(apiPost("/test", {})).rejects.toThrow("Network error");
        });

        it("sends complex request body correctly", async () => {
            const complexBody = {
                text: "Hello",
                numbers: [1, 2, 3],
                nested: { key: "value" },
            };

            (global.fetch as any).mockResolvedValue({
                ok: true,
                json: async () => ({}),
            });

            await apiPost("/test", complexBody);

            expect(global.fetch).toHaveBeenCalledWith(
                "/test",
                expect.objectContaining({
                    body: JSON.stringify(complexBody),
                }),
            );
        });
    });
});
