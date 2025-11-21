import { describe, it, expect } from 'vitest';
import { render, screen } from '@testing-library/react';
import SteampunkLayout from './SteampunkLayout';

describe('SteampunkLayout', () => {
    it('renders children content', () => {
        render(
            <SteampunkLayout>
                <div>Test Content</div>
            </SteampunkLayout>
        );
        expect(screen.getByText('Test Content')).toBeInTheDocument();
    });

    it('renders all decorative corners', () => {
        const { container } = render(
            <SteampunkLayout>
                <div>Test</div>
            </SteampunkLayout>
        );

        const corners = container.querySelectorAll('.steampunk-corner');
        expect(corners).toHaveLength(4);

        expect(container.querySelector('.top-left')).toBeInTheDocument();
        expect(container.querySelector('.top-right')).toBeInTheDocument();
        expect(container.querySelector('.bottom-left')).toBeInTheDocument();
        expect(container.querySelector('.bottom-right')).toBeInTheDocument();
    });

    it('renders header decoration with gears', () => {
        const { container } = render(
            <SteampunkLayout>
                <div>Test</div>
            </SteampunkLayout>
        );

        const headerDecoration = container.querySelector('.steampunk-header-decoration');
        expect(headerDecoration).toBeInTheDocument();

        const gears = container.querySelectorAll('.gear-small, .gear-large');
        expect(gears.length).toBeGreaterThan(0);
    });

    it('applies correct CSS classes to main layout elements', () => {
        const { container } = render(
            <SteampunkLayout>
                <div>Test</div>
            </SteampunkLayout>
        );

        expect(container.querySelector('.steampunk-layout')).toBeInTheDocument();
        expect(container.querySelector('.steampunk-border-outer')).toBeInTheDocument();
        expect(container.querySelector('.steampunk-border-inner')).toBeInTheDocument();
        expect(container.querySelector('.steampunk-content-wrapper')).toBeInTheDocument();
    });

    it('wraps content in the correct hierarchy', () => {
        const { container } = render(
            <SteampunkLayout>
                <div data-testid="test-child">Test Content</div>
            </SteampunkLayout>
        );

        const testChild = screen.getByTestId('test-child');
        const contentWrapper = container.querySelector('.steampunk-content-wrapper');

        expect(contentWrapper).toContainElement(testChild);
    });

    it('renders multiple children correctly', () => {
        render(
            <SteampunkLayout>
                <div>First Child</div>
                <div>Second Child</div>
                <div>Third Child</div>
            </SteampunkLayout>
        );

        expect(screen.getByText('First Child')).toBeInTheDocument();
        expect(screen.getByText('Second Child')).toBeInTheDocument();
        expect(screen.getByText('Third Child')).toBeInTheDocument();
    });
});
