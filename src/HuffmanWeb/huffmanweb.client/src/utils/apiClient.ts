/**
 * API client utility for making HTTP requests
 */

/**
 * Makes a POST request to the specified endpoint
 * @param endpoint - The API endpoint to call
 * @param body - The request body to send
 * @returns Promise with the response data
 */
export async function apiPost<T>(endpoint: string, body: unknown): Promise<T> {
  const response = await fetch(endpoint, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(body),
  });

  if (!response.ok) {
    throw new Error(response.statusText);
  }

  return await response.json();
}
