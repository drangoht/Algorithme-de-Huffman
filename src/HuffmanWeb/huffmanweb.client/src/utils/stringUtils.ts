/**
 * String utility functions
 */

/**
 * Removes null character (\x00) from a string
 * @param str - The string to process
 * @returns The string with null characters removed
 */
export function removeNullChar(str: string): string {
    return str.replace("\x00", "");
}
