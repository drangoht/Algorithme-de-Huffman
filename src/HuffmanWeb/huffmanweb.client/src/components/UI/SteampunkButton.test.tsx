import { describe, it, expect, vi } from 'vitest';
import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import SteampunkButton from './SteampunkButton';

describe('SteampunkButton', () => {
    it('renders the button with the correct label', () => {
        render(<SteampunkButton label="Test Button" />);
        expect(screen.getByText('Test Button')).toBeInTheDocument();
    });

    it('renders the gear icon', () => {
        render(<SteampunkButton label="Test Button" />);
        expect(screen.getByText('⚙️')).toBeInTheDocument();
    });

    it('applies active class when isActive is true', () => {
        render(<SteampunkButton label="Test Button" isActive={true} />);
        const button = screen.getByRole('button');
        expect(button).toHaveClass('active');
    });

    it('does not apply active class when isActive is false', () => {
        render(<SteampunkButton label="Test Button" isActive={false} />);
        const button = screen.getByRole('button');
        expect(button).not.toHaveClass('active');
    });

    it('calls onClick handler when clicked', async () => {
        const handleClick = vi.fn();
        const user = userEvent.setup();

        render(<SteampunkButton label="Test Button" onClick={handleClick} />);
        const button = screen.getByRole('button');

        await user.click(button);
        expect(handleClick).toHaveBeenCalledTimes(1);
    });

    it('has type="button" to prevent form submission', () => {
        render(<SteampunkButton label="Test Button" />);
        const button = screen.getByRole('button');
        expect(button).toHaveAttribute('type', 'button');
    });

    it('is disabled when disabled prop is true', () => {
        render(<SteampunkButton label="Test Button" disabled />);
        const button = screen.getByRole('button');
        expect(button).toBeDisabled();
    });

    it('applies custom className along with default classes', () => {
        render(<SteampunkButton label="Test Button" className="custom-class" />);
        const button = screen.getByRole('button');
        expect(button).toHaveClass('steampunk-btn');
        expect(button).toHaveClass('custom-class');
    });
});
