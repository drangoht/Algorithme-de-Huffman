import React from 'react';
import './SteampunkLayout.css';

interface SteampunkLayoutProps {
    children: React.ReactNode;
}

const SteampunkLayout: React.FC<SteampunkLayoutProps> = ({ children }) => {
    return (
        <div className="steampunk-layout">
            <div className="steampunk-border-outer">
                <div className="steampunk-border-inner">
                    <div className="steampunk-corner top-left"></div>
                    <div className="steampunk-corner top-right"></div>
                    <div className="steampunk-corner bottom-left"></div>
                    <div className="steampunk-corner bottom-right"></div>

                    <div className="steampunk-header-decoration">
                        <div className="gear-small spin-slow">⚙️</div>
                        <div className="gear-large spin-reverse">⚙️</div>
                        <div className="gear-small spin-slow">⚙️</div>
                    </div>

                    <div className="steampunk-content-wrapper">
                        {children}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default SteampunkLayout;
