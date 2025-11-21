import React from 'react';
import './SteampunkButton.css';

interface SteampunkButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    label: string;
    isActive?: boolean;
}

const SteampunkButton: React.FC<SteampunkButtonProps> = ({ label, isActive, className, ...props }) => {
    return (
        <button
            type="button"
            className={`steampunk-btn ${isActive ? 'active' : ''} ${className || ''}`}
            {...props}
        >
            <span className="btn-content">{label}</span>
            <span className="gear-icon">⚙️</span>
        </button>
    );
};

export default SteampunkButton;
