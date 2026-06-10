import { Box, LinearProgress } from "@mui/material";
import { SizeStatsProps } from "../../Interfaces/Encode/SizeStatsProps";

const ROW_SX = {
  display: 'grid',
  gridTemplateColumns: '160px 1fr',
  gap: '0 16px',
  alignItems: 'center',
  padding: '4px 0',
  fontFamily: 'var(--font)',
  fontSize: '0.8rem',
  animation: 'rowIn 0.3s ease both',
  '@keyframes rowIn': {
    from: { opacity: 0, transform: 'translateX(-6px)' },
    to:   { opacity: 1, transform: 'translateX(0)' },
  },
};

const SizeStats = ({ originalSize, encodedSize }: SizeStatsProps) => {
  if (originalSize <= 0) return null;

  const gainPct = ((1 - encodedSize / originalSize) * 100);
  const gainStr = gainPct.toFixed(2);
  const progressVal = Math.max(0, Math.min(100, gainPct));
  const gainColor = gainPct >= 40 ? '#22C55E' : gainPct >= 20 ? '#F59E0B' : '#F87171';

  return (
    <Box sx={{ mb: 2, background: '#000', border: '1px solid var(--border)', borderLeft: '2px solid var(--green-dim)', p: '12px 16px' }}>
      <Box sx={{ ...ROW_SX, animationDelay: '0s', color: 'rgba(134,239,172,0.4)' }}>
        <span>{'> original:'}</span>
        <span style={{ color: '#86EFAC', fontWeight: 600 }}>{originalSize} bits</span>
      </Box>
      <Box sx={{ ...ROW_SX, animationDelay: '0.06s', color: 'rgba(134,239,172,0.4)' }}>
        <span>{'> encoded:'}</span>
        <span style={{ color: '#22C55E', fontWeight: 600 }}>{encodedSize} bits</span>
      </Box>
      <Box sx={{ ...ROW_SX, animationDelay: '0.12s', color: 'rgba(134,239,172,0.4)' }}>
        <span>{'> gain:'}</span>
        <span style={{ color: gainColor, fontWeight: 700 }}>{gainStr}%</span>
      </Box>
      <Box sx={{ mt: 1.5, animation: 'rowIn 0.3s 0.18s ease both' }}>
        <LinearProgress variant="determinate" value={progressVal}
          sx={{ '& .MuiLinearProgress-bar': { background: `linear-gradient(90deg, #16A34A, ${gainColor})` } }}
        />
      </Box>
    </Box>
  );
};
export default SizeStats;
